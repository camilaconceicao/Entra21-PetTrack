import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-pop-up',
  templateUrl: './pop-up.component.html',
  styleUrls: ['./pop-up.component.css']
})
export class PopUpComponent implements OnInit {
  mostrar: boolean = false;

  toggle () {
    this.mostrar = !this.mostrar;
  }

  constructor() { }

  ngOnInit(): void {
  }

}

document.querySelector("#navs > div:nth-child(2) > div:nth-child(2)")