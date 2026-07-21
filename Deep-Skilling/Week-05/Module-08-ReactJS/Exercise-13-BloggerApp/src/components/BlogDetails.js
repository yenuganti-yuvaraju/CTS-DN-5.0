const blogs=[

{
id:1,
title:"React Learning",
author:"Stephen Biz",
content:"Welcome to learning React!"
},

{
id:2,
title:"Installation",
author:"Schwedenier",
content:"You can install React from npm."
}

];

function BlogDetails(){

return(

<div className="box">

<h2>Blog Details</h2>

{

blogs.map(blog=>(

<div key={blog.id} className="item">

<h3>{blog.title}</h3>

<h4>{blog.author}</h4>

<p>{blog.content}</p>

</div>

))

}

</div>

);

}

export default BlogDetails;