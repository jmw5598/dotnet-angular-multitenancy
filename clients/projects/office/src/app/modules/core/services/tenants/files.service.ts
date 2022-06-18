import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EnvironmentService } from '../environment.service';

@Injectable({
  providedIn: 'root'
})
export class FilesService {
  private readonly _baseEndpointSlug: string = 'files';

  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient
  ) { }

  public uploadAvatar(file: object): Observable<object> {
    return this._http.post<object>(
      `${this._environmentService.getBaseApiUrl}/${this._baseEndpointSlug}/avatar`, 
      file
    );
  }
}
