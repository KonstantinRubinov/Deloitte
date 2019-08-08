import { Component, OnInit, OnDestroy } from '@angular/core';
import { Person } from '../../models/person';
import { Store } from 'src/app/redux/store';
import { NgRedux } from 'ng2-redux';
import { Unsubscribe } from 'redux';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent  implements OnInit, OnDestroy {
  private unsubscribe:Unsubscribe;

  public haveList=false;
  public findPersons:Person[]=[];



  constructor(private redux:NgRedux<Store>) { }
  
  public ngOnInit() {}

  public haveAlist(){
    this.haveList=true;
    this.findPersons = this.redux.getState().persons;
  }

  public ngOnDestroy(): void {
    this.unsubscribe();
  }

}
