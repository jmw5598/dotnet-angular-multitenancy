import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromFiles from './files.reducer';

export const selectPlansState = createFeatureSelector<fromFiles.FilesState>(
  fromFiles.filesFeatureKey
);
