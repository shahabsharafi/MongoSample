import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PersonService {
  public peopel: Person[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {    
  }

  public getAll(): Promise<Person[]> {
    return this.http.get<Person[]>(this.baseUrl + 'peopel/all').toPromise();
  }

  public getDetails(id: string): Promise<Person> {
    return this.http.get<Person>(this.baseUrl + 'peopel/details?id=' + id).toPromise();
  }

  public create(body: Person): Promise<Object> {
    return this.http.post<Object>(this.baseUrl + 'peopel/create', body).toPromise();
  }

  public update(body: Person): Promise<Object> {
    return this.http.post<Object>(this.baseUrl + 'peopel/update', body).toPromise();
  }
}

export interface Person {
  id: string;
  name: number;
  family: number;
}
