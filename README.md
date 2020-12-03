# CatLikeCoding_CustomRP

# Note:
# 2 Draw Calls
1. SRP Batcher
It caches material properties on the GPU so they don't have to be sent every draw call. This reduces both the amount of data that has to be communicated and the work that the CPU has to do per draw call. But this only works if the shader adheres to a strict structure for uniform data.
Unfortunately the SRP batcher cannot deal with per-object material properties. 

2. GPU Instancing
GPU instancing works by issuing a single draw call for multiple objects with the same mesh at once. The CPU collects all per-object transformation and material properties and puts them in arrays which are send to the GPU. The GPU then iterates through all entries and renders them in the order that they are provided.
GPU instances requires data to be provided via arrays.
GPU instancing becomes a significant advantage when hundreds of objects can be combined in a single draw call.

3. Dynamic Batching
This is an old technique that combines multiple small meshes that share the same material into a single larger mesh that gets drawn instead. This also doesn't work when per-object material properties are used.
The larger mesh gets generated on demand, so it's only feasible for small meshes. Spheres are too large, but it does work with cubes.