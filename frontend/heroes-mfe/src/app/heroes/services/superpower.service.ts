import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SuperPower } from '../models/superpower.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SuperpowerService {

  private readonly baseUrl = 'http://localhost:5260/api/superpowers';

  constructor(private readonly http: HttpClient) {}

  getSuperPowers(): Observable<SuperPower[]> {
    return this.http.get<SuperPower[]>(this.baseUrl);
  }
}
