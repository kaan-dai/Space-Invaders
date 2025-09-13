//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class GhostMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public GhostMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            GhostMan.psActiveGhostMan = null;
            // initialize derived data here
            GhostMan.poNodeCompare = new GameObjectNode();
            GhostMan.poGameObj = new GameObjectNull();
            GhostMan.poNodeCompare.pGameObj = GhostMan.poGameObj;
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create()
        {

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new GhostMan();
            }
        }
        public static void Destroy()
        {
            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            pInstance = null;

        }

        public static GameObjectNode Attach(GameObject pGameObject)
        {
            GhostMan pMan = GhostMan.psActiveGhostMan;
            GameObjectNode pNode = (GameObjectNode)pMan.baseAdd();

            pNode.Set(pGameObject);
            return pNode;
        }

        public static GameObjectNode Find(GameObject.Name name)
        {
            GhostMan pMan = GhostMan.psActiveGhostMan;

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            Debug.Assert(GhostMan.poNodeCompare.pGameObj != null);

            GhostMan.poNodeCompare.pGameObj.name = name;

            GameObjectNode pData = (GameObjectNode)pMan.baseFind(GhostMan.poNodeCompare);

            // OK to return null
            return pData;
        }

        public static void SetActive(GhostMan pGhostMan)
        {
            GhostMan pMan = GhostMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pGhostMan != null);
            GhostMan.psActiveGhostMan = pGhostMan;
        }

        public static void Remove(GameObjectNode pNode)
        {
            Debug.Assert(pNode != null);

            GhostMan pMan = GhostMan.psActiveGhostMan;
            Debug.Assert(pMan != null);

            pMan.baseRemove(pNode);
        }

        public static void Dump()
        {
            GhostMan pMan = GhostMan.psActiveGhostMan;

            pMan.baseDump();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static GhostMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new GameObjectNode();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private static GameObjectNode poNodeCompare;
        private static GameObjectNull poGameObj;
        private static GhostMan pInstance = null;
        private static GhostMan psActiveGhostMan = null;

    }
}

// --- End of File ---
