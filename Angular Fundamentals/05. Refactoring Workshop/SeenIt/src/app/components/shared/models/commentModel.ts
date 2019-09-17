export interface CommentModel {
    author: string
    content: string
    postId: string
    _acl: { creator: string }
    _id: string
}