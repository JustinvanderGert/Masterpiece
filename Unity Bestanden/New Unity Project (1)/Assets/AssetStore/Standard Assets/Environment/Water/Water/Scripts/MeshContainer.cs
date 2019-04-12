using System;
using UnityEngine;

namespace UnityStandardAssets.Water
{
    public class MeshContainer
    {
        public Mesh mesh;
        public UnityEngine.Vector3[] vertices;
        public UnityEngine.Vector3[] normals;


        public MeshContainer(Mesh m)
        {
            mesh = m;
            vertices = m.vertices;
            normals = m.normals;
        }


        public void Update()
        {
            mesh.vertices = vertices;
            mesh.normals = normals;
        }
    }
}