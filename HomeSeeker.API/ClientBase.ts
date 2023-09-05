export class ClientBase {
    public token: string | undefined

    protected constructor() {
    }

    setAuthToken(token: string | undefined) {
        this.token = token;
    }

    protected transformOptions(options: any) {

        if (this.token) {
            options.headers["Authorization"] = "bearer " + this.token
        } else {
            console.warn("Authorization token have not been set please authorize first.");
        }
        return Promise.resolve(options);
    }
}