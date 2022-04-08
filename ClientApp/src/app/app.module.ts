import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PeopelComponent } from './peopel/peopel.component';
import { PersonComponent } from './person/person.component';
import { PersonService } from './person.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PeopelComponent,
    PersonComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: PeopelComponent, pathMatch: 'full' },
      { path: 'person-component/:id', component: PersonComponent, pathMatch: 'full' }
    ])
  ],
  providers: [
    PersonService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
