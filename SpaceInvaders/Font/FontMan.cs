//-----------------------------------------------------------------------------
// Copyright 2025, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class FontMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private FontMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            FontMan.psNodeCompare = new Font();
			Debug.Assert(FontMan.psNodeCompare != null);
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new FontMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {
            pInstance = null;

        }

        public static Font Add(Font.Name _name, SpriteBatch.Name SB_Name, string pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            FontMan pMan = FontMan.privGetInstance();

            Font pNode = (Font)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(_name, pMessage, glyphName, xStart, yStart);

            // Add to sprite batch
            SpriteBatch pSB = SpriteBatchMan.Find(SB_Name);
            Debug.Assert(pSB != null);
            Debug.Assert(pNode.poSpriteFont != null);
            pSB.Attach(pNode.poSpriteFont);

            return pNode;
        }

        public static void AddXml(Glyph.Name _glyphName, 
									string _assetName, 
									Texture.Name _textName)
        {
            GlyphMan.AddXml(_assetName, _glyphName, _textName);
        }

        public static Font Find(Font.Name _name)
        {
            FontMan pMan = FontMan.privGetInstance();

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            FontMan.psNodeCompare.mName = _name;

            Font pData = (Font)pMan.baseFind(FontMan.psNodeCompare);
            return pData;
        }

        public static void Remove(Font _pNode)
        {
            Debug.Assert(_pNode != null);

            FontMan pMan = FontMan.privGetInstance();
            pMan.baseRemove(_pNode);
        }
        public static void Dump()
        {
            FontMan pMan = FontMan.privGetInstance();
            pMan.baseDump();
        }


        //------------------------------------
        // Override Abstract methods
        //------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new Font();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //------------------------------------
        // Private methods
        //------------------------------------
        private static FontMan privGetInstance()
        {
            // Safety - this forces users to call Create() first 
			// before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }


        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static Font psNodeCompare;
        private static FontMan pInstance = null;

    }
}

// --- End of File ---
