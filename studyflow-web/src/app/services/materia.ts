import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class MateriaService {
  private http = inject(HttpClient);

  // PegarTodas(): void {
  //   return Observable<Materia[]>
  // }
}

