import React from "react";
import { Button, SafeAreaView, StyleSheet, TextInput } from "react-native";

const ButtCounter = () => {
  const [number, onChangeNumber] = React.useState("");

  return (
    <SafeAreaView>
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
              value: 'nonsense'
            }),
          })
        }
      />
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  input: {
    height: 40,
    margin: 12,
    borderWidth: 1,
    padding: 20,
  },
});
export default ButtCounter;
