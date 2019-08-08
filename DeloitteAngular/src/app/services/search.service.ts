import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../models/person';
import { Action } from '../redux/action';
import { ActionType } from '../redux/action-type';
import { Store } from '../redux/store';
import { NgRedux } from 'ng2-redux';
import { searchUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  constructor(private http: HttpClient, private redux:NgRedux<Store>) { }

  public SearchByString(str: string): void {
    let observable = this.http.get<Person[]>(searchUrl + str);
    observable.subscribe(persons=>{
      const action: Action={type:ActionType.GetPersons, payload:persons};
      this.redux.dispatch(action);
    });
    
  }

  public Search(): void {
    let observable = this.http.get<Person[]>(searchUrl);
    observable.subscribe(persons=>{
      const action: Action={type:ActionType.GetPersons, payload:persons};
      this.redux.dispatch(action);
    });
    
  }



}
