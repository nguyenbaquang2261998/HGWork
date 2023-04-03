export async function getAllProject() {

    const response = await fetch('/api/users');
    return await response.json();
}