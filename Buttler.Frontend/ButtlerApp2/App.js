import React, { useState } from "react";
import {
  Button,
  View,
  StyleSheet,
  TextInput,
  Text,
  PermissionsAndroid,
} from "react-native";
import * as Location from "expo-location";

// Function to get permission for location
const requestLocationPermission = async () => {
  try {
    const granted = await PermissionsAndroid.request(
      PermissionsAndroid.PERMISSIONS.ACCESS_FINE_LOCATION,
      {
        title: "Geolocation Permission",
        message: "Can we access your location?",
        buttonNeutral: "Ask Me Later",
        buttonNegative: "Cancel",
        buttonPositive: "OK",
      }
    );
    console.log("granted", granted);
    if (granted === "granted") {
      console.log("You can use Geolocation");
      return true;
    } else {
      console.log("You cannot use Geolocation");
      return false;
    }
  } catch (err) {
    return false;
  }
};

const ButtCounter = () => {
  const [number, onChangeNumber] = React.useState("");
  const [location, setLocation] = useState(false);
  const [viewLocation, isViewLocation] = useState([]);

  // function to check permissions and get Location
  const getLocation = async () => {
    const { status } = await Location.requestForegroundPermissionsAsync();
    if (status !== "granted") {
      console.log("Permission denied. Enter the location manually.");
      return;
    }
        const location = await Location.getCurrentPositionAsync({});
        console.log(location);
        setLocation(location);
    };

  return (
    <View
      style={{
        alignContent: "center",
        justifyContent: "center",
        height: "100%",
      }}
    >
      <TextInput
        style={styles.input}
        onChangeText={onChangeNumber}
        value={number}
        placeholder="Butt count"
        keyboardType="numeric"
      />
      <Button
        title="Submit"
        onPress={() =>
          fetch("https://m1w13.wiremockapi.cloud/json", {
            method: "POST",
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
            body: JSON.stringify({
              id: number,
              value: "nonsense",
            }),
          })
        }
      />
      <View
        style={{ marginTop: 10, padding: 10, borderRadius: 10, width: "40%" }}
      >
        <Button title="Get Location" onPress={getLocation} />
      </View>
      <Text>Latitude: {location ? location.coords.latitude : null}</Text>
      <Text>Longitude: {location ? location.coords.longitude : null}</Text>
    </View>
  );
};

const styles = StyleSheet.create({
  input: {
    height: 80,
    margin: 12,
    borderWidth: 1,
    padding: 20,
  },
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
});
export default ButtCounter;
