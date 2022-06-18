import { createAction } from '@ngrx/store';

export const uploadAvatarRequest = createAction(
  '[Files] Upload Avatar Request'
);

export const uploadAvatarRequestSuccess = createAction(
  '[Files] Upload Avatar Request Success'
);

export const uploadAvatarRequestFailure = createAction(
  '[Files] Upload Avatar Request Failure'
);
