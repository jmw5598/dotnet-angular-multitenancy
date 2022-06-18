import { RegistrationCompany } from './registration-company.model';
import { RegistrationPlan } from './registration-plan.model';
import { RegistrationProfile } from './registration-profile.model';
import { RegistrationUser } from './registration-user.model';

export interface Registration {
  user: RegistrationUser,
  profile: RegistrationProfile,
  company: RegistrationCompany,
  plan: RegistrationPlan
}
