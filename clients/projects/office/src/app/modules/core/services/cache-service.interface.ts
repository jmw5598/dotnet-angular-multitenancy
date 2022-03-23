import { InjectionToken } from "@angular/core";

export const CACHE_SERVICE: InjectionToken<string> = new InjectionToken<string>('CACHE_SERVICE');

export interface ICacheService {
  setItem<T>(key: string, t: T): void;
  getItem<T>(key: string): T | null;
  removeItem<T>(key: string): void;
  clear(): void;
}
