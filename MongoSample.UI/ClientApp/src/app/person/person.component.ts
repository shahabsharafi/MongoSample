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
  public mode: PersonComponentMode = PersonComponentMode.create;
  public title: string = '';

  constructor(private route: ActivatedRoute, private location: Location, private formBuilder: FormBuilder, private service: PersonService) {
    this.route.params.subscribe(params => {
      let id = params['id'];
      this.getDetails(id);
    });    
  }

  getDetails(id: string): void {
    if (id != undefined) {
      this.service.getDetails(id).then((result: Person) => {
        this.personForm = this.formBuilder.group(result);
        this.mode = PersonComponentMode.update;
        this.title = 'Update ' + result.name + ' ' + result.family;
      }, (error: any) => console.error(error));
    } else {
      this.personForm = this.formBuilder.group(new Person());
      this.mode = PersonComponentMode.create;
      this.title = 'Add new person';
    }
  }

  onSubmit(): void {
    const person: Person = <Person>this.personForm.value;
    if (this.mode == PersonComponentMode.update) {
      this.service.update(person).then((result: any) => {
        console.warn('Your record has been update', person);
        this.personForm.reset();
        this.location.back();
      }, (error: any) => console.error(error));
    } else {
      this.service.create(person).then((result: any) => {
        console.warn('Your record has been add', person);
        this.personForm.reset();
        this.location.back();
      }, (error: any) => console.error(error));
    }
  }

  onCancel(): void {
    this.location.back();
  }
}
export enum PersonComponentMode {
    update,
    create
}
