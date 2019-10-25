import React, { Component } from 'react'
import { Map as LeafletMap, TileLayer, Marker, Popup } from 'react-leaflet'
import LocateControl from './LocateControl'
import axios from 'axios'
import https from 'https'

const axiosInstance = axios.create({ httpsAgent: new https.Agent({ rejectUnauthorized: false }) });

const MarkerList = (props) => (
    <div>
        {props.markers.map(marker => <MarkerWidget key={marker.id} {...marker} />)}
    </div>
);

class MarkerWidget extends Component {
    render() {
        const marker = this.props;
        return (
            <Marker position={[marker.latitude, marker.longitude]}>
                <Popup>
                    <h4>{marker.name}</h4>
                    <p>{marker.description}</p>
                    <a class="button" href={marker.linkTo} class="btn" type="button">Plan reis hierheen met 9292OV</a>
                    <a class="button" href={marker.linkFrom} class="btn" type="button">Plan reis hiervandaan met 9292OV</a>
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
            lat: 52.088301631793456,
            lng: 5.107164851899615,
            zoom: 13,
            markers: []
        };
    }

    handleMoveEnd = async (event) => {
        let newCoordinates = event.target.getCenter();

        const response = await axiosInstance.get('https://localhost:5001/api/Place',
            {
                params: {
                    latitude: newCoordinates.lat,
                    longitude: newCoordinates.lng,
                    radius: 10000
                }
            });
        console.log(response);
        this.setState({ markers: response.data });
    }

    render() {
        const position = [this.state.lat, this.state.lng];
        const locateOptions = {
            position: 'topright',
            strings: {
                title: 'Show me where I am'
            },
            onActivate: () => { }// callback before engine starts retrieving locations
        }; 
        return (
            <LeafletMap
                center={position}
                zoom={this.state.zoom}
                onMoveEnd={this.handleMoveEnd}>
                <TileLayer attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png">
                </TileLayer>
                <LocateControl options={locateOptions} startDirectly />
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