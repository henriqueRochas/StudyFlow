import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Materia } from './models/materia';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {
  protected readonly title = signal('StudyFlow');

  materias: Materia[] = [
    { id: 1, nome: 'C# Avançado'},
    { id: 2, nome: 'C# Intermediario' },
    { id: 3, nome: 'C# Basico' },
  ];

}


