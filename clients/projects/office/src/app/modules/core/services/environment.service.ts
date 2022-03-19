import { Inject, Injectable } from '@angular/core';
import { environment } from '@xyz/office/env/environment';

export interface EnvironmentSettings {
  production: boolean,
  api: ApiSettings
}

export interface ApiSettings {
  protocol: string,
  subdomain: string,
  domain: string,
  port: string,
  apiSlug: string,
  authSlug: string
}

@Injectable({
  providedIn: 'root'
})
export class EnvironmentService {
  private _env: EnvironmentSettings = environment;

  constructor(
    @Inject(Window)
    private _window: Window
  ) { }

  public getEnvironmentSettings(): EnvironmentSettings {
    return this._env;
  }

  public getBaseApiUrl(): string {
    const subdomain: string = this.getSubdomain();
    const port: string = this._env.api.port?.length ? `:${this._env.api.port}` : ''; 
    return `${this._env.api.protocol}://${subdomain}.${this._env.api.domain}${port}/${this._env.api.apiSlug}`;
  }

  public getBaseAuthUrl(): string {
    const subdomain: string = this.getSubdomain();
    const port: string = this._env.api.port?.length ? `:${this._env.api.port}` : ''; 
    return `${this._env.api.protocol}://${subdomain}.${this._env.api.domain}${port}/${this._env.api.authSlug}`;
  }

  public getSubdomain(): string {
    return this._window.location.hostname.split(".")[0]
  }
}
