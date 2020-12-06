import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  isMenuOpened: boolean = false;

  constructor() { }

  ngOnInit(): void {
    this.isMenuOpened = <boolean>JSON.parse(localStorage.getItem('menuOpened'));
  }

  onMenuToggled() {
    this.isMenuOpened = !this.isMenuOpened;
    localStorage.setItem('menuOpened', JSON.stringify(this.isMenuOpened));
    console.warn('Menu state', this.isMenuOpened);
  }
}
