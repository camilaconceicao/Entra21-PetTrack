import { Location } from '@angular/common';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
  styleUrls: ['./mapa.component.css']
})
export class MapaComponent implements AfterViewInit {
  private map: any;

  private initMap(): void {
    this.map = L.map('map', {

      center: [-28.678452737325486, -49.375954887903106],
      zoom: 15
    });

    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      minZoom: 13,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });

    const circle1 = L.circle([-28.67480776728617, -49.363290028982355], {
      color: 'red',
      fillColor: '#f03',
      fillOpacity: 0.3,
      radius: 250
    }).addTo(this.map);
    circle1.bindPopup("Tito")

    const circle2 = L.circle([-28.674521664922693, -49.36180222788466], {
      color: 'red',
      fillColor: '#f03',
      fillOpacity: 0.3,
      radius: 250
    }).addTo(this.map);
    circle2.bindPopup("Dior")

    const circle3 = L.circle([-28.668723838457367, -49.35985514676218], {
      color: 'red',
      fillColor: '#f03',
      fillOpacity: 0.3,
      radius: 250
    }).addTo(this.map);
    circle3.bindPopup("Duque")
      

    tiles.addTo(this.map);
  }

  constructor(
    private location: Location
  ) { }

  ngAfterViewInit(): void {
    this.initMap();
  }

  public back() {
    return this.location.back()
  }
}