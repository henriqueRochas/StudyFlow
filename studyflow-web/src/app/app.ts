import { Component, inject, signal, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Materia } from './models/materia';
import { MateriaService } from './services/materia';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

//OnInir É UMA INTERFACE DO PROPRIO ANGULAR
export class App implements OnInit{
  protected readonly title = signal('StudyFlow');

  private materiaService = inject(MateriaService);

  //O signal É UM FUNÇÃO QUE DEIXA O ESTADO REATIVO E ATUALIZADO
  materias = signal<Materia[]>([]);

  //SUBSCRIBE: INICIA A REQUISIÇÃO
  //É EXECUTADO QUANDO A API RESPONDE COM SUCESSO
  //MATERIA RECEBE OS DADOS
  //THIS.MATERIAS = MATERIAS: ATRIBUI A RESPOSTA DA API NA PROPRIEDADE MATERIA
  //ERROR TRATA A FALHA DA REQUISIÇÃO CASO OCORRA
  ngOnInit(): void{
    this.materiaService.PegarTodas().subscribe({
      next: (materias) => {
        this.materias.set(materias);
      },
      error: (erro) => {
        console.error(erro);
      }
    });
  }
}


