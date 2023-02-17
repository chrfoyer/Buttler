import React, { useState } from "react";
import {
  Button,
  View,
  StyleSheet,
  TextInput,
  Text,
  PermissionsAndroid,
  Alert,
} from "react-native";
import * as Location from "expo-location";

const ButtCounter = () => {
  const [number, onChangeNumber] = React.useState("");
  const [location, setLocation] = useState(false);

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

  const sendCount = () => {
    fetch("http://34.141.254.228/api/Reports", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        numberOfWaste: number,
        wasteType: 1,
        latitude: location.coords.latitude,
        longitude: location.coords.longitude
      }),
    });
    console.log(number + " butts logged");
    Alert.alert("Success", "You logged " + number + " butts");
  };

  return (
    <View style={styles.container}>
      <TextInput
        style={styles.input}
        onChangeText={onChangeNumber}
        value={number}
        placeholder="Butts"
        keyboardType="numeric"
      />
      <View style={styles.button}>
        <Button title="Submit" onPress={sendCount} style />
      </View>
      <View style={styles.button}>
        <Button title="Get Location" onPress={getLocation} />
      </View>
      <Text>Latitude: {location ? location.coords.latitude : null}</Text>
      <Text>Longitude: {location ? location.coords.longitude : null}</Text>
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
});
export default ButtCounter;
