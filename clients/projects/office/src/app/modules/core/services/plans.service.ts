import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Plan } from '../entities';
import { AbstractCrudService } from './abstract-crud.service';
import { EnvironmentService } from './environment.service';

@Injectable({
  providedIn: 'root'
})
export class PlansService extends AbstractCrudService<Plan, string> {
  constructor(
    protected http: HttpClient,
    protected environmentService: EnvironmentService
  ) {
    super(http, environmentService, 'plans');
  }
}
