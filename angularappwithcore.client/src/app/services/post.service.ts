import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private apiUrl = 'https://localhost:7129/api/Values';

  constructor(private client: HttpClient) { }

  getPosts(): Observable<any> {
    return this.client.get(this.apiUrl);
  }
}
