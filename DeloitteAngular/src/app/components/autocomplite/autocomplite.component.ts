import { Component, OnInit, OnDestroy } from '@angular/core';
import { SearchService } from 'src/app/services/search.service';
import { Person } from '../../models/person';
import { Store } from 'src/app/redux/store';
import { NgRedux } from 'ng2-redux';
import { Unsubscribe } from 'redux';

@Component({
  selector: 'app-autocomplite',
  templateUrl: './autocomplite.component.html',
  styleUrls: ['./autocomplite.component.css']
})
export class AutocompliteComponent implements OnInit, OnDestroy {
  public str:string="";
  public persons:Person[]=[];
  public focus=false;
  private unsubscribe:Unsubscribe;

  constructor(private search: SearchService, private redux:NgRedux<Store>) { }

  public ngOnInit() {
    this.SearchByString();
  }

  public SearchByString():void {
    if (this.str.length==0){
      this.search.Search();
    } else if (this.str.length==1){
      this.persons=null;
    } else {
      this.search.SearchByString(this.str);
    }
    this.unsubscribe = this.redux.subscribe(()=>{
      this.persons = this.redux.getState().persons;
    });
  }

  public focusFunction(){
    this.focus=true;
  };
  public focusOutFunction(){
    this.focus=false;
  };

  public ngOnDestroy(): void {
    this.unsubscribe();
  }

}
