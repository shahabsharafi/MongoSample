import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PersonService, Person } from '../person.service';

@Component({
  selector: 'peopel',
  templateUrl: './peopel.component.html'
})
export class PeopelComponent {
  public peopel: Person[] = [];

  constructor(private route: ActivatedRoute, private service: PersonService) {
    this.route.params.subscribe(params => {
      this.getAll();
    });
  }

  getAll(): void {
    this.service.getAll().then((result: Person[]) => {
      this.peopel = result;
    }, (error: any) => console.error(error));
  }
}
