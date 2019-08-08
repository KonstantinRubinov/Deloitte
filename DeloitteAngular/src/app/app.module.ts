import { NgModule }         from '@angular/core';
import { BrowserModule }    from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './modules/app-routing.module';

import { FormsModule }   from '@angular/forms';


import { LayoutComponent } from './components/layout/layout.component';
import { PersonCardComponent } from './components/person-card/person-card.component';
import { Store } from './redux/store';
import { Reducer } from './redux/reducer';

import { NgReduxModule, NgRedux } from 'ng2-redux';
import { HeaderComponent } from './components/header/header.component';
import { MainComponent } from './components/main/main.component';
import { AutocompliteComponent } from './components/autocomplite/autocomplite.component';

@NgModule({
  declarations: [
    LayoutComponent,
    PersonCardComponent,
    HeaderComponent,
    MainComponent,
    AutocompliteComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    NgReduxModule
    
  ],
  providers: [],
  bootstrap: [LayoutComponent]
})
export class AppModule {
  public constructor(redux:NgRedux<Store>){
    redux.configureStore(Reducer.reduce, new Store());
  }
 }
