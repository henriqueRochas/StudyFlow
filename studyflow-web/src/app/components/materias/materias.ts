import { Component, inject, signal, OnInit } from '@angular/core';
import { Materia } from '../../models/materia';
import { MateriaService } from '../../services/materia';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-materias', //IDENTIFICADOR DO COMPONENTE, PERMITE USAR ELE NO HTML COMO SE FOSSE UMA TAG
  imports: [FormsModule], 
  templateUrl: './materias.html', // INDICA ONDE ESTA O HTML
  styleUrl: './materias.css', // INDICA ONDE ESTA O CSS

})
export class Materias  implements OnInit {
  private materiaService = inject(MateriaService);

  //O signal É UM FUNÇÃO QUE DEIXA O ESTADO REATIVO E ATUALIZADO
  materias = signal<Materia[]>([]);
  nomeNovaMateria = signal<string>("");

  //SUBSCRIBE: INICIA A REQUISIÇÃO
  //É EXECUTADO QUANDO A API RESPONDE COM SUCESSO
  //MATERIA RECEBE OS DADOS
  //THIS.MATERIAS = MATERIAS: ATRIBUI A RESPOSTA DA API NA PROPRIEDADE MATERIA
  //ERROR TRATA A FALHA DA REQUISIÇÃO CASO OCORRA
  ngOnInit(): void {
    this.materiaService.PegarTodas().subscribe({
      next: (materias) => {
        this.materias.set(materias);
      },
      error: (erro) => {
        console.error(erro);
      }
    });
  }

  CadastrarMateria(): void {

    this.materiaService.Adicionar(this.nomeNovaMateria()).subscribe({

      next: (materiaCriada) => {

        this.materias.update((listaAtual) => {
          return [...listaAtual, materiaCriada];
        });

        this.nomeNovaMateria.set('');
      },

      error: (erro) => {
        console.error(erro);
      }

    });

  }
 }

