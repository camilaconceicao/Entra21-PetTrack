import { Location } from '@angular/common';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as L from 'leaflet';

@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
  styleUrls: ['./mapa.component.css']
})
export class MapaComponent implements AfterViewInit {
  private map: any;
  latitude: number = 0;
  longitude: number = 0;

  constructor(private route: ActivatedRoute,private location: Location) {}

  private initMap(): void {

    this.route.params.subscribe(params => {
      this.latitude = Number.parseFloat(params['lat']); 
      this.longitude =  Number.parseFloat(params['long']); 

      console.log(this.latitude);
      console.log(this.longitude);
    });

    this.map = L.map('map', {

      center: [this.latitude,this.longitude],
      zoom: 12
    });

    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 15,
      minZoom: 10,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });

    const circle1 = L.circle([this.latitude,this.longitude], {
      color: 'red',
      fillColor: '#f03',
      fillOpacity: 0.3,
      radius: 4000
    }).addTo(this.map);
    circle1.bindPopup("Última localização informada!")

    tiles.addTo(this.map);
  }

  ngAfterViewInit(): void {
    this.initMap();
  }

  public back() {
    return this.location.back()
  }
}