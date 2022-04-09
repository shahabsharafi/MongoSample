import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService, Person } from '../person.service';
import f from 'odata-filter-builder';

@Component({
  selector: 'peopel',
  templateUrl: './peopel.component.html'
})
export class PeopelComponent {
  public peopel: Person[] = [];
  public name: string = '';
  public family: string = '';

  constructor(private router: Router, private route: ActivatedRoute, private service: PersonService) {
    this.route.params.subscribe(params => {
      this.getAll();
      this.name = '';
      this.family = '';
    });
  }

  getAll(filter: string = ''): void {
    this.service.getAll(filter).then((result: Person[]) => {
      this.peopel = result;
    }, (error: any) => console.error(error));
  }

  onDelete(id: string): void {
    this.service.delete(id).then(() => {
      this.getAll();
    }, (error: any) => console.error(error));
  }

  onAdd(): void {
    this.router.navigate(['/person-component']);
  }

  onSearch(): void {
    if (this.name != '' || this.family != '') {
      let q = f('or');
      if (this.name != '')
        q = q.eq('Name', this.name);
      if (this.family != '')
        q = q.eq('Family', this.family);
      const filter = q.toString();
      console.log(filter);
      this.getAll(filter);
    } else {
      this.getAll();
    }
  }
}
