import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Furniture } from '../models/funiture';

@Injectable()
export class FurnitureService {
  private readonly furnitureCreateUrl: string = 'http://localhost:5000/furniture/create';
  private readonly furnitureAllUrl: string = 'http://localhost:5000/furniture/all';
  private readonly furnitureDetail: string = 'http://localhost:5000/furniture/details/';
  private readonly furnitureUser: string = 'http://localhost:5000/furniture/user';
  private readonly furnitureDelete: string = 'http://localhost:5000/furniture/delete/';
  private readonly furniturePut: string = 'http://localhost:5000/furniture/edit/';

  constructor(private httpClient: HttpClient) {
  }

  createFuniture(obj) : Observable<Furniture> {
    return this.httpClient.post<Furniture>(this.furnitureCreateUrl, obj);
  }

  getAllFunitures() : Observable<Array<Furniture>> {
    return this.httpClient.get<Array<Furniture>>(this.furnitureAllUrl);
  }

  getFurniture(id) : Observable<Furniture> {
    const obs = this.httpClient.get<Furniture>(this.furnitureDetail + id);
    return obs;
  }

  getUserFurnitures() : Observable<Array<Furniture>> {
    return this.httpClient.get<Array<Furniture>>(this.furnitureUser);
  }

  deleteFurniture(id) : Observable<any> {
    return this.httpClient.delete(this.furnitureDelete + id);
  }

  edit(id, obj) : Observable<any> {
    return this.httpClient.put(this.furniturePut + id, obj);
  }
}
