import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SecurityGeneralComponent } from './pages/security-general/security-general.component';

const routes: Routes = [
  {
    path: '',
    component: SecurityGeneralComponent
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityGeneralRoutingModule { }
