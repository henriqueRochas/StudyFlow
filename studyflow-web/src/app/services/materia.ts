import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Materia } from '../models/materia';

@Injectable({
  providedIn: 'root',
})

export class MateriaService {
  private http = inject(HttpClient);

  PegarTodas(): Observable<Materia[]> { // USA O MÉTODO GET PARA BUSCAS AS INFORMAÇÕES
    return this.http.get<Materia[]>('http://localhost:5057/api/materias');
  }

  Adicionar(nome: string): Observable<Materia> {
    return this.http.post<Materia>('http://localhost:5057/api/materias', {nome: nome});
  }
}

