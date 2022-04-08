import { Component, Inject } from '@angular/core';
import { Location } from '@angular/common';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PersonService, Person } from '../person.service';

@Component({
  selector: 'person',
  templateUrl: './person.component.html'
})
export class PersonComponent {
  public personForm: any; 

  constructor(private route: ActivatedRoute, private location: Location, private formBuilder: FormBuilder, private service: PersonService) {
    this.route.params.subscribe(params => {
      let id = params['id'];
      this.getDetails(id);
    });    
  }

  getDetails(id: string): void {
    this.service.getDetails(id).then((result: Person) => {
      this.personForm = this.formBuilder.group(result);
    }, (error: any) => console.error(error));
  }

  onSubmit(): void {
    const person: Person = <Person>this.personForm.value;
    this.service.update(person).then((result: any) => {
      console.warn('Your order has been submitted', person);
      this.personForm.reset();
      this.location.back();
    }, (error: any) => console.error(error));    
  }
}
