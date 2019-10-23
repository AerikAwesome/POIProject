import React, { Component } from 'react'
import { Map as LeafletMap, TileLayer, Marker, Popup } from 'react-leaflet'


const testData = [
    { lat: 51.505, lng: -0.09, text: "This is a test marker" }
];

const MarkerList = (props) => (
    <div>
        {props.markers.map(marker => <MarkerWidget {...marker} />)}
    </div>
);

class MarkerWidget extends Component {
    render() {
        const marker = this.props;
        return (
            <Marker position={[marker.lat, marker.lng]}>
                <Popup>
                    {marker.text}
          </Popup>
            </Marker>
            );
    }
}

class MapWidget extends Component
{
    constructor(props) {
        super(props);
        this.state = {
            lat: 51.505,
            lng: -0.09,
            zoom: 13,
            markers: testData
        };
    }

    render() {
        const position = [this.state.lat, this.state.lng];
        return (
            <LeafletMap
                center={position}
                zoom={this.state.zoom}>
                <TileLayer attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png">
                </TileLayer>
                <MarkerList markers={this.state.markers}/>
            </LeafletMap>
        );
    }
}

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <MapWidget />
            </div>
        );
    }
}
