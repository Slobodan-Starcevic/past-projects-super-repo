import useAuthStore from "./auth/authStore"

export function isAdmin() {
    const {user} = useAuthStore();
    return user && user.role == 'ADMIN';
};

export function isLoggedIn() {
    const {user} = useAuthStore();
    return user ?? false;
};

export function isOwnerOrAdmin(objectOwnerId){
    const {user} = useAuthStore();
    return user.userId == objectOwnerId || user.role == 'ADMIN';
}