import { createAction, props } from "@ngrx/store";
import { Plan } from "@xyz/office/modules/core/entities/multitenancy";
import { ResponseMessage } from "@xyz/office/modules/core/models";

export const getPlansRequest = createAction(
  '[Plans] Get Plans Request'
);

export const getPlansRequestSuccess = createAction(
  '[Plans] Get Plans Request Success',
  props<{ plans: Plan[]}>()
);

export const getPlansRequestFailure = createAction(
  '[Plans] Get Plans Request Failure',
  props<{ message: ResponseMessage }>()
);
