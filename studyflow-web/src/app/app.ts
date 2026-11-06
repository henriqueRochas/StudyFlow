import { Component } from '@angular/core';
import { Materias } from './components/materias/materias';


@Component({
  selector: 'app-root',
  imports: [Materias],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

//OnInir É UMA INTERFACE DO PROPRIO ANGULAR
export class App {

}


