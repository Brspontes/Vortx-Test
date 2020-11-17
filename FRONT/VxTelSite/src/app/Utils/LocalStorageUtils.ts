export class LocalStorageUtils {
    
    public obterUsuario() {
        return JSON.parse(localStorage.getItem('vxtel.user'));
    }

    public salvarDadosLocaisUsuario(response: any) {
        this.salvarTokenUsuario(response.accessToken);
        this.salvarUsuario(response.userToken);
    }

    public limparDadosLocaisUsuario() {
        localStorage.removeItem('vxtel.token');
        localStorage.removeItem('vxtel.user');
    }

    public obterTokenUsuario(): string {
        return localStorage.getItem('vxtel.token');
    }

    public salvarTokenUsuario(token: string) {
        localStorage.setItem('vxtel.token', token);
    }

    public salvarUsuario(user: string) {
        localStorage.setItem('vxtel.user', JSON.stringify(user));
    }

}