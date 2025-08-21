import { CanActivateFn } from '@angular/router';

export const rotaGuard: CanActivateFn = (route, state) => {
  return true;
};
