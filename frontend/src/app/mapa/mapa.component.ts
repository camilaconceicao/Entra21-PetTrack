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

      center: [ -28.678452737325486, -49.375954887903106 ],
      zoom: 16
    });

    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      minZoom: 8,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });

    

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