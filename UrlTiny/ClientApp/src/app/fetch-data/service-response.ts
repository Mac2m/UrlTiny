export class ServiceResponse<T> {
  data: T;
  errorMessage: string;
  succeeded: boolean;
}
