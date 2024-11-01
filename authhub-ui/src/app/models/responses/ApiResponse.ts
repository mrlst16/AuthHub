export class ApiResponse<T>{
    Data: T | undefined;
    Success: boolean | undefined;
    Errors: ApiError[] = [];
}

export class ApiError{
    Message: string | undefined;
    ErrorCode: string | undefined;
    StackTrace: string | undefined;
}