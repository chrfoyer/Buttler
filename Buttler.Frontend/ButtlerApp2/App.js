import React from "react";
import { Button, View, StyleSheet, TextInput, TouchableOpacity } from "react-native";

const ButtCounter = () => {
  const [number, onChangeNumber] = React.useState("Beer");

  return (
    <View style={{ justifyContent: "center", height: "100%" }}>
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
});
export default ButtCounter;
