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
  mensagemCadastro = signal<string>("");
  materiaSelecionada = signal<Materia | null>(null);

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
    const limpandoEspacoEmBranco = this.nomeNovaMateria().trim();

    if (limpandoEspacoEmBranco.length < 3) {
      this.mensagemCadastro.set('Informe pelo menos 3 caracteres');
      return
    }

    this.materiaService.Adicionar(limpandoEspacoEmBranco).subscribe({

      next: (materiaCriada) => {

        this.materias.update((listaAtual) => {
          return [...listaAtual, materiaCriada];
        });

        this.nomeNovaMateria.set('');
        this.mensagemCadastro.set('Cadastrado com sucesso!');
      },

      error: (erro) => {
        console.error(erro);
        this.mensagemCadastro.set('Erro ao cadastrar!');
      }

    });
  }

  SelecionarMateria(materia: Materia) {
    this.materiaSelecionada.set(materia);
    this.nomeNovaMateria.set(materia.nome);
  }

  AtualizarMateria() {
    const materiaAtual = this.materiaSelecionada();

    if (materiaAtual === null) {
      return;
    }

    const nomeAtualizado = this.nomeNovaMateria().trim();

    if (nomeAtualizado.length < 3) {
      this.mensagemCadastro.set('Informe pelo menos 3 caracteres');
      return;
    }

    this.materiaService.Atualizar(materiaAtual.id, nomeAtualizado).subscribe({
      next: (materiaAtualizada) => {

        this.materias.update((listaAtual) => {

          return listaAtual.map((materia) => {

            if (materia.id === materiaAtualizada.id) {
              return materiaAtualizada;
            }

            return materia;
          });
        });
      },

      error: (erro) => {
        console.error(erro);
        this.mensagemCadastro.set('Erro ao Atualizar');
      }
    })
  }

  SalvarMateria(): void {
    if (this.materiaSelecionada() === null) {
      this.CadastrarMateria();
    } else {
      this.AtualizarMateria();
    }
  }

  DeletarMateria(materia: Materia): void {

    this.materiaService.Deletar(materia.id).subscribe({

      next: (materiaExcluida) => {

        this.materias.update((listaAtual) => {
            return listaAtual.filter((item) => {
              return item.id !== materiaExcluida.id;
          });
        });

        this.mensagemCadastro.set('Matéria removida com sucesso!');

        const selecionada = this.materiaSelecionada();

        if (selecionada !== null && selecionada.id === materiaExcluida.id) {
          this.materiaSelecionada.set(null);
          this.nomeNovaMateria.set('');
        }
      },

      error: (erro) => {
        console.error(erro);
        this.mensagemCadastro.set('Erro ao excluir matéria!');
      }

    });
  }

 }

