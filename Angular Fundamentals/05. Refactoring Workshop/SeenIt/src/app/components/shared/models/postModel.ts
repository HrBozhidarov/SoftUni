export interface PostModel {
    _id: string
    author: string
    description: string
    imageUrl: string
    title: string
    url: string
    _acl: { creator: string }
}