import React from "react";
import MapView, { PROVIDER_GOOGLE, Marker, Heatmap } from "react-native-maps";
import { StyleSheet } from "react-native";

const MapScreen = ({ location, markers, showMarkers }) => {
  return (
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
      {!showMarkers ? (
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
      ) : (
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
      )}
    </MapView>
  );
};

const styles = StyleSheet.create({
  map: {
    flex: 1,
    width: "100%",
    height: "100%",
  },
});

export default MapScreen;
