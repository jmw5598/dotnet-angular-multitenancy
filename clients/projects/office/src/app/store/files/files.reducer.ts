import { createReducer, on } from '@ngrx/store';

import * as fromFiles from './files.actions';

export const filesFeatureKey = 'files';

export interface FilesState {

}

export const initialFilesState: FilesState = {

}

export const reducer = createReducer(
  initialFilesState
);
