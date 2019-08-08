import { Component, OnInit, Input } from '@angular/core';
import { Person } from 'src/app/models/person';

@Component({
  selector: 'app-person-card',
  templateUrl: './person-card.component.html',
  styleUrls: ['./person-card.component.css']
})
export class PersonCardComponent implements OnInit {
  @Input() person: Person;
  @Input() str: string = "";
  constructor() { }

  public splittedName;
  public splittedWork;

  ngOnInit() {
    if (this.str.length>1){
      this.splittedName = this.person.name.split(this.str, 2);
      if (this.splittedName.length<2)
      this.splittedName=null;
  
      this.splittedWork = this.person.workTitle.split(this.str, 2); 
      if (this.splittedWork.length<2)
        this.splittedWork=null;
    }
    
  }

}
