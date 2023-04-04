import React, { useRef, useState, useEffect, useMemo } from "react";
import {
  AppState,
  Button,
  View,
  StyleSheet,
  TextInput,
  Text,
  PermissionsAndroid,
  Alert,
} from "react-native";
import * as Location from "expo-location";
import MapView, { PROVIDER_GOOGLE, Marker, Heatmap } from "react-native-maps";

const ButtCounter = () => {
  const [number, onChangeNumber] = React.useState("");
  const [loading, setLoading] = useState(true);
  const [showMarkers, setShowMarkers] = useState(true);
  const appState = useRef(AppState.currentState);
  const [appStateVisible, setAppStateVisible] = useState(appState.current);
  const [location, setLocation] = useState(null);
  const [markers, setMarkers] = useState([]);
  const markerMemo = useMemo(() => getMarkers, [markers]);

  // function to check permissions and get Location
  const getLocation = async () => {
    try {
      const { status } = await Location.requestForegroundPermissionsAsync();
      if (status !== "granted") {
        console.log("Permission denied. Enter the location manually.");
        return;
      }
      const location = await Location.getCurrentPositionAsync({});
      console.log(location);
      setLocation(location);
    } catch (error) {
      console.log(error);
      Alert.alert("Error", "Failed to get location. Please try again.");
    }
  };

  const getMarkers = async () => {
    try {
      const response = await fetch("http://34.90.196.163/api/Reports");
      const markers = await response.json();
      setMarkers(markers);
      setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    const subscription = AppState.addEventListener("change", (nextAppState) => {
      if (
        appState.current.match(/inactive|background/) &&
        nextAppState === "active"
      ) {
        console.log("App has come to the foreground!");
        getLocation();
      }

      appState.current = nextAppState;
      setAppStateVisible(appState.current);
      console.log("AppState", appState.current);
    });

    getLocation();
    getMarkers();
    return () => {
      subscription.remove();
    };
  }, []);

  const sendCount = async () => {
    try {
      const response = await fetch("http://34.90.196.163/api/Reports", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          userName: "anon",
          numberOfWaste: number,
          wasteType: 1,
          latitude: location.coords.latitude,
          longitude: location.coords.longitude,
        }),
      });
      if (!response.ok) {
        throw new Error("Failed to submit count");
      }
      console.log(number + " butts logged");
      Alert.alert("Success", "You logged " + number + " butts");
    } catch (error) {
      console.log(error);
      Alert.alert("Error", "Failed to submit count. Please try again.");
    }
  };

  const toggleMarkers = () => {
    setShowMarkers(!showMarkers);
  };

  return (
    <View style={styles.container}>
      <View style={styles.switchButton}>
        <Button title="Heatmap or Markers" onPress={() => toggleMarkers()} />
      </View>
      <Text>How many 🚬 on the ground?</Text>
      <TextInput
        style={styles.input}
        onChangeText={onChangeNumber}
        value={number}
        placeholder="🔢"
        keyboardType="numeric"
      />
      <View style={styles.button}>
        <Button title="Submit" onPress={sendCount} style />
      </View>
      {location && (
        <MapView
          provider={PROVIDER_GOOGLE}
          style={styles.map}
          initialRegion={{
            latitude: location.coords.latitude,
            longitude: location.coords.longitude,
            latitudeDelta: 0.015,
            longitudeDelta: 0.0121,
          }}
          showsUserLocation={true}
          showsMyLocationButton={true}
        >
          {
            !showMarkers && location ?(
              <Heatmap
                points={markers.map((marker) => ({
                  latitude: marker.latitude,
                  longitude: marker.longitude,
                  weight: marker.numberOfWaste,
                }))}
                opacity={1}
                radius={50}
                gradient={{
                  colors: ["#00ADEF", "#00639C", "#FFC500", "#FF6900", "#FF0D00"],
                  startPoints: [0.01, 0.25, 0.5, 0.75, 1],
                  colorMapSize: 256,
                }}
              />
            ) :
            markers.map((marker) => (
              <Marker
                key={marker.reportid}
                coordinate={{
                  latitude: marker.latitude,
                  longitude: marker.longitude,
                }}
                title={`Number of Butts: ${marker.numberOfWaste}`}
              />
            ))
          }
          {markerMemo}
        </MapView>
      )}
    </View>
  );
};

const styles = StyleSheet.create({
  input: {
    height: 100,
    margin: 12,
    borderWidth: 1,
    padding: 5,
    width: "40%",
    textAlign: "center",
    fontSize: 60,
  },
  button: {
    marginTop: 10,
    padding: 10,
    borderRadius: 10,
    width: "40%",
  },
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
    height: "100%",
  },
  map: {
    height: "50%",
    width: "100%",
  },
});
export default ButtCounter;
